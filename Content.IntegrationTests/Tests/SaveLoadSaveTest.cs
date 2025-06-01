using System.IO;
using System.Linq;
using Content.Shared.CCVar;
using Robust.Shared.Configuration;
using Robust.Shared.ContentPack;
using Robust.Shared.EntitySerialization.Systems;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.Map.Events;
using Robust.Shared.Serialization.Markdown.Mapping;
using Robust.Shared.Utility;

namespace Content.IntegrationTests.Tests
{
    /// <summary>
    ///     Tests that a grid's yaml does not change when saved consecutively.
    /// </summary>
    [TestFixture]
    public sealed class SaveLoadSaveTest
    {
        [Test]
        public async Task CreateSaveLoadSaveGrid()
        {
            await using var pair = await PoolManager.GetServerClient();
            var server = pair.Server;
            var entManager = server.ResolveDependency<IEntityManager>();
            var mapLoader = entManager.System<MapLoaderSystem>();
            var mapSystem = entManager.System<SharedMapSystem>();
            var mapManager = server.ResolveDependency<IMapManager>();
            var cfg = server.ResolveDependency<IConfigurationManager>();
            Assert.That(cfg.GetCVar(CCVars.GridFill), Is.False);

            var testSystem = server.System<SaveLoadSaveTestSystem>();
            testSystem.Enabled = true;

            var rp1 = new ResPath("/save load save 1.yml");
            var rp2 = new ResPath("/save load save 2.yml");

            await server.WaitPost(() =>
            {
                mapSystem.CreateMap(out var mapId0);
                var grid0 = mapManager.CreateGridEntity(mapId0);
                entManager.RunMapInit(grid0.Owner, entManager.GetComponent<MetaDataComponent>(grid0));
                Assert.That(mapLoader.TrySaveGrid(grid0.Owner, rp1));
                mapSystem.CreateMap(out var mapId1);
                Assert.That(mapLoader.TryLoadGrid(mapId1, rp1, out var grid1));
                Assert.That(mapLoader.TrySaveGrid(grid1!.Value, rp2));
            });

            await server.WaitIdleAsync();
            var userData = server.ResolveDependency<IResourceManager>().UserData;

            string one;
            string two;

            await using (var stream = userData.Open(rp1, FileMode.Open))
            using (var reader = new StreamReader(stream))
            {
                one = await reader.ReadToEndAsync();
            }

            await using (var stream = userData.Open(rp2, FileMode.Open))
            using (var reader = new StreamReader(stream))
            {
                two = await reader.ReadToEndAsync();
            }

            Assert.Multiple(() =>
            {
                Assert.That(two, Is.EqualTo(one));
                var failed = TestContext.CurrentContext.Result.Assertions.FirstOrDefault();
                if (failed != null)
                {
                    var oneTmp = Path.GetTempFileName();
                    var twoTmp = Path.GetTempFileName();

                    File.WriteAllText(oneTmp, one);
                    File.WriteAllText(twoTmp, two);

                    TestContext.AddTestAttachment(oneTmp, "First save file");
                    TestContext.AddTestAttachment(twoTmp, "Second save file");
                    TestContext.Error.WriteLine("Complete output:");
                    TestContext.Error.WriteLine(oneTmp);
                    TestContext.Error.WriteLine(twoTmp);
                }
            });
            testSystem.Enabled = false;
            await pair.CleanReturnAsync();
        }

        /// <summary>
        /// Simple system that modifies the data saved to a yaml file by removing the timestamp.
        /// Required by some tests that validate that re-saving a map does not modify it.
        /// </summary>
        private sealed class SaveLoadSaveTestSystem : EntitySystem
        {
            public bool Enabled;
            public override void Initialize()
            {
                SubscribeLocalEvent<AfterSerializationEvent>(OnAfterSave);
            }

            private void OnAfterSave(AfterSerializationEvent ev)
            {
                if (!Enabled)
                    return;

                // Remove timestamp.
                ((MappingDataNode)ev.Node["meta"]).Remove("time");
            }
        }
    }
}

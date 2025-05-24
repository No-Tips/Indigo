# Indigo

---

This is a fork of [Einstein Engines](https://github.com/Simple-Station/Einstein-Engines).

## Building

Refer to [the Space Wizards' guide](https://docs.spacestation14.com/en/general-development/setup/setting-up-a-development-environment.html) on setting up a development environment for general information, but keep in mind that Einstein Engines is not the same and many things may not apply.
We provide some scripts shown below to make the job easier.

### Build dependencies

> - Git
> - .NET SDK 9.0.101
> - [Pkl](https://pkl-lang.org/main/current/pkl-cli/index.html#installation)

Before running a server or a client run `Content.TypingsGenerator` and eval all the `.pkl` files into YAML.
You can use scripts `Scripts/sh/genTypings.sh` and `Scripts/sh/pklEval.sh` for this.

### Windows

> 1. Clone this repository
> 2. Run `git submodule update --init --recursive` in a terminal to download the engine
> 3. Run `Scripts/bat/buildAllDebug.bat` after making any changes to the source
> 4. Run `Scripts/bat/runQuickAll.bat` to launch the client and the server
> 5. Connect to localhost in the client and play

### Linux & MacOS

> 1. Clone this repository
> 2. Run `git submodule update --init --recursive` in a terminal to download the engine
> 3. Run `Scripts/sh/buildAllDebug.sh` after making any changes to the source
> 4. Run `Scripts/sh/runQuickAll.sh` to launch the client and the server
> 5. Connect to localhost in the client and play

## License

Please read the [LEGAL.md](./LEGAL.md) file for information on the licenses of the code and assets in this repository.

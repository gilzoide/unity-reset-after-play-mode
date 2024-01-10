# Reset After Play Mode
[![openupm](https://img.shields.io/npm/v/com.gilzoide.reset-after-play-mode?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.gilzoide.reset-after-play-mode/)

Editor-only `ScriptableObject` that resets other assets' properties after exiting Play Mode.

Use this to avoid unwanted diffs in source control for `Material`s, `ScriptableObject`s or other assets that get modified during gameplay.


## How to install
Either:
- Use the [openupm registry](https://openupm.com/) and install this package using the [openupm-cli](https://github.com/openupm/openupm-cli):
  ```
  openupm add com.gilzoide.reset-after-play-mode
  ```
- Install using the [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html) with the following URL:
  ```
  https://github.com/gilzoide/unity-reset-after-play-mode.git#1.0.0
  ```
- Clone this repository or download a snapshot of it directly inside your project's `Assets` or `Packages` folder.
- Just copy the [ResetAfterPlayMode.cs](Editor/ResetAfterPlayMode.cs) script into your project. Since it works in the editor only, feel free to add it inside an `Editor` folder to avoid the script being included in builds.


## How to use
1. Use the `Assets -> Create -> Reset After Play Mode` menu item to create an instance of the `ResetAfterPlayMode` object in your project.
   
   Since it works in the editor only, make sure to save this new asset to an `Editor` folder to avoid it getting included in builds.
2. Add the assets that should be reset after exiting play mode in its `Assets` list.
3. Play the game. Modify the assets however you want during gameplay.
4. After exiting Play Mode, check that the assets are back to their initial state.
5. Enjoy 🍾
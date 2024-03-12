# Lightning Effect
Initial, and most of the design, is taken from [here](https://www.patreon.com/posts/21393747)

## Lightning Package
The final version of the Lightning effect is a package that could be imported anywhere. Within this is a Prefab, and everything else is bundled in it's own folders for cleanliness

IMAGE

## Sound Management
Sound Management is done using very simple scripting. The [Thunder Effect](https://www.youtube.com/watch?v=77jgQCkgObI). audio felt good enough. Once the audio was imported into Unity, the `Audio Source` component was added into the Prefab. Nothing is configured on this component, as everything would be controlled via a script.

IMAGE

The `ElectricityController` script provides support for audio, based on examples from [this site](https://levelup.gitconnected.com/how-to-play-sound-effects-in-unity-6a122bb32970)

## Lightning Controls
**TODO**... details on what was changed, and how the ElectricityController functions were designed

## Usage
To use the Lightning Effect, simply drag the `Electricity` prefab (in the *Lightning* folder) into a Scene. Then:
1. On the object's `Electricity Controller` component, configure the `Height` and `Radius` of the object. Both are measured in terms of Unity units. Also configure the `start_x` and `start_y` parameters, which set the Location of the lightning effect
2. Make sure the `InTesting` checkbox is not selected, and that the `thunder` field has the right audio file selected (the audio file is under *Lightning/Sounds*)

NOTE: Currently, the Lightning effect works best at heights of 20-30 units.

By configuring the Height and Location, you are ensuring that the Lightning effect will start at the correct height and location once the game starts (the ElectricityController component takes care of this)

### Usage via Scripting

The `ElectricityController.cs` script also provides the ability to control the Lightning effect from outside, and at any time. The following functions from the script are useful for this:
```
void StartElectricity();    // to start the effect (which takes ~5-7 sec)

void ChangeLocation(float x, float z);  // to change the location of the effect's origin (in global coordinates)

void ChangeHeight(float height);    // to change the height at which the effect's origin is located (in global coordinates)

void ChangeRadius(float radius);    // to change the effect's spread (in terms of Unity units)
```
Run any of these by accessing the Electricty Controller component of the prefab from any other script.

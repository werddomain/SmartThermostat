using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ST.Web.API.GoogleSmartHomeModel
{
    public class action
    {
        public class devices {
            /// <summary>
            /// Requests the list of devices that the user has connected and are available for use
            /// </summary>
            public const string SYNC = "action.devices.SYNC";

            /// <summary>
            /// Queries for the current states of devices
            /// </summary>
            public const string QUERY = "action.devices.QUERY";

            /// <summary>
            /// Requests a command to execute on smart home devices. The new state should be provided in response if available. One EXECUTE intent can target multiple devices, with multiple commands.
            /// </summary>
            public const string EXECUTE = "action.devices.EXECUTE";

            /// <summary>
            ///  Informs your app when a user has unlinked the app account from the Google Assistant. After receiving a DISCONNECT intent, you should not report state for this user's devices.
            /// </summary>
            public const string DISCONNECT = "action.devices.DISCONNECT";

            public class types {
                // DOC: https://developers.google.com/actions/smarthome/guides/

                /// <summary>
                /// Air conditioning units are similar to thermostats, but do not support heating and may not support setting temperature targets, but rather rely on modes, toggles, and fan speed settings (for example, high and low).
                /// </summary>
                public const string AC_UNIT = "action.devices.types.AC_UNIT";

                /// <summary>
                /// Air purifiers can be turned on and off and may support adjusting fan speed levels. Some may also have various toggles or modes, and each mode has its own related settings. These are specific to the air purifier and are interpreted in a generalized form.
                /// </summary>
                public const string AIRPURIFIER = "action.devices.types.AIRPURIFIER";

                /// <summary>
                /// Cameras are complex and features will vary significantly between vendors. Over time, cameras will acquire many traits and attributes describing specific capabilities, many of which may interact with the video/audio stream in special ways, such as sending a stream to another device, identifying what's in the stream, replaying feeds, etc. As such, cameras also interact with other devices - especially screens and other media targets.
                /// </summary>
                public const string CAMERA = "action.devices.types.CAMERA";

                /// <summary>
                /// Interactions with coffee makers may include turning them on and off, adjusting the target temperature, and adjusting various mode settings.
                /// </summary>
                public const string COFFEE_MAKER = "action.devices.types.COFFEE_MAKER";

                /// <summary>
                /// Dishwashers can have start and stop functionality independent from being on or off (some washers have separate power buttons, and some do not). Some can be paused and resumed while washing.

                /// Dishwashers also have various modes and each mode has its own related settings.These are specific to the dishwasher and are interpreted in a generalized form.
                /// </summary>
                public const string DISHWASHER = "action.devices.types.DISHWASHER";

                /// <summary>
                /// Dryers have start and stop functionality independent from being on or off. Some can be paused and resumed while drying.

                ///Dryers also have various modes and each mode has its own related settings.These are specific to the dryer and are interpreted in a generalized form.
                /// </summary>
                public const string DRYER = "action.devices.types.DRYER";

                /// <summary>
                /// Fans can typically be turned on and off and have speed settings. Some fans may also have additional supported modes, such as fan direction/orientation (for example, a wall unit may have settings to adjust whether it blows up or down).
                /// </summary>
                public const string FAN = "action.devices.types.FAN";

                /// <summary>
                /// Kettles are devices that boil water. Interactions with kettles may include turning them on and off, adjusting the target temperature, and perhaps adjusting various mode settings.
                /// </summary>
                public const string KETTLE = "action.devices.types.KETTLE";

                /// <summary>
                /// This type indicates that the device gets the light bulb icon and some light synonyms/aliases.
                /// </summary>
                public const string LIGHT = "action.devices.types.LIGHT";

                /// <summary>
                /// This type indicates that the device gets the plug icon and some outlet synonyms/aliases.
                /// </summary>
                public const string OUTLET = "action.devices.types.OUTLET";

                /// <summary>
                /// Interaction with ovens involves the ability to bake or broil at certain temperatures. The physical temperature inside the oven differs as the oven is heating, so this may also be monitored. The oven has a cook time that limits the duration of baking.
                /// </summary>
                public const string OVEN = "action.devices.types.OVEN";

                /// <summary>
                /// This type indicates that the device gets the appropriate icon and some refrigerator synonyms/aliases. Refrigerators are temperature-managing devices which may have various modes/settings.
                /// </summary>
                public const string REFRIGERATOR = "action.devices.types.REFRIGERATOR";

                /// <summary>
                /// Scenes defined here are partner scenes, implemented as virtual devices and activated by name.
                /// </summary>
                public const string SCENE = "action.devices.types.SCENE";

                /// <summary>
                /// Sprinklers can start and stop (or turn on and off). In the future, they may support timers and/or schedules.
                /// </summary>
                public const string SPRINKLER = "action.devices.types.SPRINKLER";

                /// <summary>
                /// This type indicates that the device gets the switch icon and some switch synonyms/aliases.
                /// </summary>
                public const string SWITCH = "action.devices.types.SWITCH";

                /// <summary>
                /// Thermostats are temperature-managing devices, with set points and modes. This separates them from heaters and AC units which may only have modes and settings (for example, high/low) vs a temperature target.
                /// </summary>
                public const string THERMOSTAT = "action.devices.types.THERMOSTAT";

                /// <summary>
                /// Vacuums can have binary modes and settings (for example, on/off and start/pause) as well as a mode to schedule cleaning sessions and a mode to charge themselves. Partners can construct their vacuum cleaner specifics using a combination of these standard modes, as well as the Dock trait to support returning for charge.
                /// </summary>
                public const string VACUUM = "action.devices.types.VACUUM";

                /// <summary>
                /// Washers can have start and stop functionality independent from being on or off (some washers have separate power buttons, and some do not). Some can be paused and resumed while washing.

                /// Washers also have various modes and each mode has its own related settings.These are specific to the washer and are interpreted in a generalized form.
                /// </summary>
                public const string WASHER = "action.devices.types.WASHER";

            }

            public class traits {
                //DOC: https://developers.google.com/actions/smarthome/traits/

                /// <summary>
                /// Absolute brightness setting is in a normalized range from 0 to 100 (individual lights may not support every point in the range based on their LED configuration).
                /// </summary>
                public const string Brightness = "action.devices.traits.Brightness";

                /// <summary>
                /// This trait belongs to devices which have the capability to stream video feeds to third party screens, Chromecast-connected screens or an Android phone. By and large, these are currently security cameras or baby cameras. But this would also apply to more complex devices which have a camera on them (for example, video-conferencing robotics/devices or a vacuum robot with a camera on it).
                /// </summary>
                public const string CameraStream = "action.devices.traits.CameraStream";

                /// <summary>
                /// This trait applies to devices, such as smart lights, that can change color or color temperature.
                /// </summary>
                public const string ColorSetting = "action.devices.traits.ColorSetting";

                /// <summary>
                /// This trait is designed for self-mobile devices that can be commanded to return for charging.
                /// </summary>
                public const string Dock = "action.devices.traits.Dock";

                /// <summary>
                /// This trait belongs to devices that support setting the speed of a fan (that is, blowing air from the device at various levels, which may be part of an air conditioning or heating unit, or in a car), with settings such as low, medium, and high.
                /// </summary>
                public const string FanSpeed = "action.devices.traits.FanSpeed";

                /// <summary>
                /// This trait is used for devices that can be "found". This includes phones, robots (including vacuums and mowers), drones, and tag-specific products that attach to other devices.
                /// </summary>
                public const string Locator = "action.devices.traits.Locator";

                /// <summary>
                /// This trait belongs to any devices with an arbitrary number of "n-way" modes in which the modes and settings for each mode are arbitrary and unique to each device or device type. Each mode has multiple possible settings, but only one can be selected at a time; a dryer cannot be in "delicate," "normal," and "heavy duty" mode simultaneously. A setting that simply can be turned on or off belongs in the Toggles trait.
                /// </summary>
                public const string Modes = "action.devices.traits.Modes";

                /// <summary>
                /// The basic on and off functionality for any device that has binary on and off, including plugs and switches as well as many future devices.
                /// </summary>
                public const string OnOff = "action.devices.traits.OnOff";

                /// <summary>
                /// This trait represents any device that has an ongoing duration for its operation which can be queried. This includes, but is not limited to, devices that operate cyclically, such as washing machines, dryers, and dishwashers.
                /// </summary>
                public const string RunCycle = "action.devices.traits.RunCycle";

                /// <summary>
                /// 
                /// </summary>
                public const string DISCONNECT = "action.devices.traits.";

                /// <summary>
                /// In the case of scenes, the type maps 1:1 to the trait, as scenes don't combine with other traits to form composite devices.
                /// </summary>
                public const string Scene = "action.devices.traits.Scene";

                /// <summary>
                /// Starting and stopping a device serves a similar function to turning it on and off. Devices that inherit this trait function differently when turned on and when started. Unlike devices that simply have an on and off state, some devices that can start and stop are also able to pause while performing operation.
                /// </summary>
                public const string StartStop = "action.devices.traits.StartStop";

                /// <summary>
                /// Trait for devices (other than thermostats) that support controlling temperature, either within or around the device. This includes devices such as ovens and refrigerators.
                /// </summary>
                public const string TemperatureControl = "action.devices.traits.TemperatureControl";

                /// <summary>
                /// This trait covers handling both temperature point and modes.
                /// </summary>
                public const string TemperatureSetting = "action.devices.traits.TemperatureSetting";

                /// <summary>
                /// This trait belongs to any devices with settings that can only exist in one of two states. These settings can represent a physical button with an on/off or active/inactive state, a checkbox in HTML, or any other sort of specifically enabled/disabled element.
                /// </summary>
                public const string Toggles = "action.devices.traits.Toggles";

            }
        }
    }
}

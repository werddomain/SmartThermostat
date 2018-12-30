using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ST.SmartDevices.Google;
namespace ST.Web.API.Data
{
    public class SeedData
    {
        public static void EnsureSeedData(IConfiguration Configuration, IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DeviceDataContext>();
                context.Database.Migrate();

                Seed_DeviceTraits(context);
                context.SaveChanges();

                Seed_DeviceTypes(context);
                context.SaveChanges();
            }
        }
        static void Seed_DeviceTraits(DeviceDataContext context)
        {
            //DOC: https://developers.google.com/actions/smarthome/traits/
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.Brightness, "Absolute brightness setting is in a normalized range from 0 to 100 (individual lights may not support every point in the range based on their LED configuration).");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.CameraStream, "This trait belongs to devices which have the capability to stream video feeds to third party screens, Chromecast-connected screens or an Android phone. By and large, these are currently security cameras or baby cameras. But this would also apply to more complex devices which have a camera on them (for example, video-conferencing robotics/devices or a vacuum robot with a camera on it).");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.ColorSetting, "This trait applies to devices, such as smart lights, that can change color or color temperature.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.Dock, "This trait is designed for self-mobile devices that can be commanded to return for charging.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.FanSpeed, "This trait belongs to devices that support setting the speed of a fan (that is, blowing air from the device at various levels, which may be part of an air conditioning or heating unit, or in a car), with settings such as low, medium, and high.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.Locator, "This trait is used for devices that can be \"found\". This includes phones, robots (including vacuums and mowers), drones, and tag-specific products that attach to other devices.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.Modes, "This trait belongs to any devices with an arbitrary number of \"n - way\" modes in which the modes and settings for each mode are arbitrary and unique to each device or device type. Each mode has multiple possible settings, but only one can be selected at a time; a dryer cannot be in \"delicate, \" \"normal, \" and \"heavy duty\" mode simultaneously. A setting that simply can be turned on or off belongs in the Toggles trait.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.OnOff, "The basic on and off functionality for any device that has binary on and off, including plugs and switches as well as many future devices.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.RunCycle, "This trait represents any device that has an ongoing duration for its operation which can be queried. This includes, but is not limited to, devices that operate cyclically, such as washing machines, dryers, and dishwashers.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.Scene, "In the case of scenes, the type maps 1:1 to the trait, as scenes don't combine with other traits to form composite devices.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.StartStop, "Starting and stopping a device serves a similar function to turning it on and off. Devices that inherit this trait function differently when turned on and when started. Unlike devices that simply have an on and off state, some devices that can start and stop are also able to pause while performing operation.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.TemperatureControl, "Trait for devices (other than thermostats) that support controlling temperature, either within or around the device. This includes devices such as ovens and refrigerators.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.TemperatureSetting, "This trait covers handling both temperature point and modes.");
            CheckAndAdd(context, context.DeviceTraits, action.devices.traits.Toggles, "This trait belongs to any devices with settings that can only exist in one of two states. These settings can represent a physical button with an on/off or active/inactive state, a checkbox in HTML, or any other sort of specifically enabled/disabled element.");


        }
        static void Seed_DeviceTypes(DeviceDataContext context)
        {
            //DOC: https://developers.google.com/actions/smarthome/guides/
            CheckAndAdd(context, context.DeviceTypes, action.devices.types.AC_UNIT, 
                "Air conditioning units are similar to thermostats, but do not support heating and may not support setting temperature targets, but rather rely on modes, toggles, and fan speed settings (for example, high and low).", null, 
                action.devices.traits.TemperatureSetting, 
                action.devices.traits.OnOff, 
                action.devices.traits.Modes, 
                action.devices.traits.Toggles, 
                action.devices.traits.FanSpeed);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.AIRPURIFIER, 
                "Air purifiers can be turned on and off and may support adjusting fan speed levels. Some may also have various toggles or modes, and each mode has its own related settings. These are specific to the air purifier and are interpreted in a generalized form.", null, 
                action.devices.traits.OnOff, 
                action.devices.traits.FanSpeed, 
                action.devices.traits.Modes, 
                action.devices.traits.Toggles);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.CAMERA, 
                "Cameras are complex and features will vary significantly between vendors. Over time, cameras will acquire many traits and attributes describing specific capabilities, many of which may interact with the video/audio stream in special ways, such as sending a stream to another device, identifying what's in the stream, replaying feeds, etc. As such, cameras also interact with other devices - especially screens and other media targets. ", null, 
                action.devices.traits.CameraStream);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.COFFEE_MAKER, 
                "Interactions with coffee makers may include turning them on and off, adjusting the target temperature, and adjusting various mode settings.", null, 
                action.devices.traits.TemperatureControl, 
                action.devices.traits.OnOff, 
                action.devices.traits.Modes, 
                action.devices.traits.Toggles);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.DISHWASHER, 
                "Dishwashers can have start and stop functionality independent from being on or off (some washers have separate power buttons, and some do not). Some can be paused and resumed while washing. " + Environment.NewLine + "Dishwashers also have various modes and each mode has its own related settings. These are specific to the dishwasher and are interpreted in a generalized form. ", null, 
                action.devices.traits.OnOff, 
                action.devices.traits.Modes, 
                action.devices.traits.Toggles,
                action.devices.traits.StartStop, 
                action.devices.traits.RunCycle);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.DRYER, 
                "Dryers have start and stop functionality independent from being on or off. Some can be paused and resumed while drying. " + Environment.NewLine + "Dryers also have various modes and each mode has its own related settings. These are specific to the dryer and are interpreted in a generalized form. ", null, 
                action.devices.traits.OnOff, 
                action.devices.traits.Modes, 
                action.devices.traits.Toggles, 
                action.devices.traits.StartStop, 
                action.devices.traits.RunCycle);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.FAN, 
                "Fans can typically be turned on and off and have speed settings. Some fans may also have additional supported modes, such as fan direction/orientation (for example, a wall unit may have settings to adjust whether it blows up or down).", null, 
                action.devices.traits.FanSpeed, 
                action.devices.traits.OnOff, 
                action.devices.traits.Modes, 
                action.devices.traits.Toggles);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.KETTLE, 
                "Kettles are devices that boil water. Interactions with kettles may include turning them on and off, adjusting the target temperature, and perhaps adjusting various mode settings.", null, 
                action.devices.traits.TemperatureControl, 
                action.devices.traits.OnOff, 
                action.devices.traits.Modes, 
                action.devices.traits.Toggles);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.LIGHT, 
                "This type indicates that the device gets the light bulb icon and some light synonyms/aliases.", null, 
                action.devices.traits.OnOff, 
                action.devices.traits.Brightness, 
                action.devices.traits.ColorSetting);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.OUTLET, 
                "This type indicates that the device gets the plug icon and some outlet synonyms/aliases.", null, 
                action.devices.traits.OnOff);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.OVEN, 
                "Interaction with ovens involves the ability to bake or broil at certain temperatures. The physical temperature inside the oven differs as the oven is heating, so this may also be monitored. The oven has a cook time that limits the duration of baking. ", null, 
                action.devices.traits.TemperatureControl, 
                action.devices.traits.StartStop, 
                action.devices.traits.OnOff,
                action.devices.traits.Modes, 
                action.devices.traits.Toggles);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.REFRIGERATOR, 
                "This type indicates that the device gets the appropriate icon and some refrigerator synonyms/aliases. Refrigerators are temperature-managing devices which may have various modes/settings. ", null, 
                action.devices.traits.TemperatureControl, 
                action.devices.traits.OnOff, 
                action.devices.traits.Modes, 
                action.devices.traits.Toggles);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.SCENE, 
                "Scenes defined here are partner scenes, implemented as virtual devices and activated by name. ", null, 
                action.devices.traits.Scene);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.SPRINKLER, 
                "Sprinklers can start and stop (or turn on and off). In the future, they may support timers and/or schedules.", null,
                action.devices.traits.StartStop);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.SWITCH, 
                "This type indicates that the device gets the switch icon and some switch synonyms/aliases.", null, 
                action.devices.traits.OnOff);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.THERMOSTAT, 
                "Thermostats are temperature-managing devices, with set points and modes. This separates them from heaters and AC units which may only have modes and settings (for example, high/low) vs a temperature target. ", null, 
                action.devices.traits.TemperatureSetting);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.VACUUM, 
                "Vacuums can have binary modes and settings (for example, on/off and start/pause) as well as a mode to schedule cleaning sessions and a mode to charge themselves. Partners can construct their vacuum cleaner specifics using a combination of these standard modes, as well as the Dock trait to support returning for charge.", null, 
                action.devices.traits.OnOff, 
                action.devices.traits.Modes, 
                action.devices.traits.Toggles, 
                action.devices.traits.Dock, 
                action.devices.traits.StartStop);

            CheckAndAdd(context, context.DeviceTypes, action.devices.types.WASHER, 
                "Washers can have start and stop functionality independent from being on or off (some washers have separate power buttons, and some do not). Some can be paused and resumed while washing. " + Environment.NewLine + "Washers also have various modes and each mode has its own related settings. These are specific to the washer and are interpreted in a generalized form. ", null,
                action.devices.traits.OnOff, 
                action.devices.traits.Modes,
                action.devices.traits.Toggles, 
                action.devices.traits.StartStop, 
                action.devices.traits.RunCycle);


        }
        static void CheckAndAdd(DeviceDataContext context, DbSet<SmartDevices.Devices.Google.DeviceTrait> dbset, string Id, string Description, string DisplayName = null)
        {
            if (DisplayName == null)
                DisplayName = Id.Split('.').Last();
            
            if (!dbset.Any(o => o.DeviceTraitId == Id))
                dbset.Add(new SmartDevices.Devices.Google.DeviceTrait { DeviceTraitId = Id, Description = Description, DisplayName = DisplayName });

        }
        static void CheckAndAdd(DeviceDataContext context, DbSet<SmartDevices.Devices.Google.DeviceType> dbset, string Id, string Description, string DisplayName = null, params string[] RecommandedTraits)
        {
            if (DisplayName == null)
                DisplayName = Id.Split('.').Last();
            IEnumerable<SmartDevices.Devices.Google.DeviceTrait> recommendedTraits = null;
            if (RecommandedTraits != null && RecommandedTraits.Length > 0)
                recommendedTraits = context.DeviceTraits.Where(o => RecommandedTraits.Contains(o.DeviceTraitId));

            if (!dbset.Any(o => o.DeviceTypeId == Id)) {
                var device = new SmartDevices.Devices.Google.DeviceType { DeviceTypeId = Id, Description = Description, DisplayName = DisplayName };
                if (recommendedTraits != null && recommendedTraits.Any())
                    device.RecommendedTraits = recommendedTraits.ToList();
                dbset.Add(device);
            }
                

        }
    }
}

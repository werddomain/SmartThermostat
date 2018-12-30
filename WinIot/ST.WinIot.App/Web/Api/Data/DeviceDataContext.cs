using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ST.Web.API.Data
{
    public class DeviceDataContext: DbContext
    {
        public DeviceDataContext() {

        }

        public DbSet<ST.SmartDevices.Devices.Hub> Hubs { get; set; }
        public DbSet<ST.SmartDevices.Devices.Home> Homes { get; set; }
        public DbSet<ST.SmartDevices.Devices.Device> Devices { get; set; }
        public DbSet<ST.SmartDevices.Devices.Piece> Pieces { get; set; }
        public DbSet<ST.SmartDevices.Devices.Relay> Relays { get; set; }

        public DbSet<ST.SmartDevices.Devices.Google.DeviceTrait> DeviceTraits { get; set; }
        public DbSet<ST.SmartDevices.Devices.Google.DeviceType> DeviceTypes { get; set; }
        public DbSet<ST.SmartDevices.Devices.GoogleUser> GoogleUsers { get; set; }




    }
}

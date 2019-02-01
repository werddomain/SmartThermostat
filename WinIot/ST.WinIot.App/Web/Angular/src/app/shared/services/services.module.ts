import { NgModule } from '@angular/core';
import * as services from './'
import { ModuleWithProviders } from '@angular/compiler/src/core';

@NgModule({})
export class ServicesModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: ServicesModule,
            providers: [
                services.AngularService,
                services.DevicesService,
                services.DeviceTraitsService,
                services.HomesService,
                services.HubsService,
                services.PiecesService,
                services.RelaysService
            ]
        };
    }
}

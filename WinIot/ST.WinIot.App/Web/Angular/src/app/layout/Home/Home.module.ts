import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './Home-routing.module';
import { HomeComponent } from './Home.component';

import { HomesService } from "../../shared/services/Homes.service";
import { PageHeaderModule } from './../../shared';
@NgModule({
    imports: [CommonModule, HomeRoutingModule, PageHeaderModule],
    declarations: [HomeComponent],
    providers: [HomesService]
})
export class HomeModule {

}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './Home-routing.module';
import { HomeComponent } from './Home.component';

import { HomesService } from "../../shared/services/Homes.service";

@NgModule({
    imports: [CommonModule, HomeRoutingModule],
    declarations: [HomeComponent],
    providers: [HomesService]
})
export class HomeModule {}

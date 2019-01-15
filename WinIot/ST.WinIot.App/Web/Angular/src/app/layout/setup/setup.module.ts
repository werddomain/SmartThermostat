import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { setupRoutingModule } from './setup-routing.module';
import { setupComponent } from './setup.component';
import { SetupService } from "./setup.service"
import { BreadCrumbModule } from "../../shared"
@NgModule({
    imports: [CommonModule, setupRoutingModule, BreadCrumbModule],
    declarations: [setupComponent],
    providers: [SetupService]
})
export class setupModule {}

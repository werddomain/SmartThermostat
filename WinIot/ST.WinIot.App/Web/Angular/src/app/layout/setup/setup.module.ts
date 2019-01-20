import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { setupRoutingModule } from './setup-routing.module';
import { setupComponent } from './setup.component';
import { SetupService } from "./setup.service"
import { BreadCrumbModule } from "../../shared"
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation';

@NgModule({
    imports: [CommonModule, setupRoutingModule, BreadCrumbModule, FormsModule, ReactiveFormsModule, NgBootstrapFormValidationModule],
    declarations: [setupComponent],
    providers: [SetupService]
})
export class setupModule {}

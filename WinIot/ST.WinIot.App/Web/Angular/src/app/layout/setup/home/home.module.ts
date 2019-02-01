import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { homeRoutingModule } from './home-routing.module';
import { homeComponent } from './home.component';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation'; //https://github.com/third774/ng-bootstrap-form-validation
import { SetupService } from "../setup.service"
@NgModule({
    imports: [CommonModule, homeRoutingModule, FormsModule, ReactiveFormsModule, NgBootstrapFormValidationModule],
    declarations: [homeComponent]
})
export class homeModule {}

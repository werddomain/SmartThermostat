import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { piecesRoutingModule } from './pieces-routing.module';
import { piecesComponent } from './pieces.component';
import { SetupService } from "../setup.service"
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation'; //https://github.com/third774/ng-bootstrap-form-validation

@NgModule({
    imports: [CommonModule, piecesRoutingModule, FormsModule, ReactiveFormsModule, NgBootstrapFormValidationModule ],
    declarations: [piecesComponent]
})
export class piecesModule {}

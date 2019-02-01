import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { piecesRoutingModule } from './pieces-routing.module';
import { piecesComponent } from './pieces.component';
import { SetupService } from "../setup.service"

@NgModule({
    imports: [CommonModule, piecesRoutingModule],
    declarations: [piecesComponent]
})
export class piecesModule {}

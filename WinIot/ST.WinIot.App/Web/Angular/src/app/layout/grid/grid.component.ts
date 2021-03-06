import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';
import { HomesService } from "../../shared/services/Homes.service";
@Component({
    selector: 'app-grid',
    templateUrl: './grid.component.html',
    styleUrls: ['./grid.component.less'],
    animations: [routerTransition()]
})
export class GridComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}

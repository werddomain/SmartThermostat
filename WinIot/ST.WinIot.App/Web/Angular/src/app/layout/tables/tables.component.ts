import { Component, OnInit } from '@angular/core';
import { routerTransition } from '../../router.animations';

@Component({
    selector: 'app-tables',
    templateUrl: './tables.component.html',
    styleUrls: ['./tables.component.less'],
    animations: [routerTransition()]
})
export class TablesComponent implements OnInit {
    constructor() {}

    ngOnInit() {}
}

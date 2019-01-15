import { Component, OnInit, Input } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
    selector: 'app-bread-crumb',
    templateUrl: './bread-crumb.component.html',
    styleUrls: ['./bread-crumb.component.less']
})
/** bread-crumb component*/
export class BreadCrumbComponent {
    /** bread-crumb ctor */
    @Input() heading: string;
    @Input() items: BreadCrumbItem[]
    constructor() {

    }
}
export class BreadCrumbItem {
    name: string;
    icon: string;
    active: boolean;
    route?: string;
}

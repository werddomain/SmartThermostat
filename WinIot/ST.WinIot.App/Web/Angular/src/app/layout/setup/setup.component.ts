import { Component, OnInit } from '@angular/core';
import { SetupService } from "./setup.service"
import { BreadCrumbItem } from '../../shared/modules/bread-crumb/bread-crumb.component';

@Component({
    selector: 'app-setup',
    templateUrl: './setup.component.html',
    styleUrls: ['./setup.component.less']
})
export class setupComponent implements OnInit {
    constructor(private setupService: SetupService) {
        
    }
    public BreadCrumbs: BreadCrumbItem[]
    ngOnInit() {
        this.setupService.fireBreadCrumbItemChanged.subscribe(o => { this.BreadCrumbs = o; });
        this.setupService.SetBreadCrumb([{
            active: false,
            icon: "fa-cogs",
            name: "Setup",
            route: "/setup"
        }]);
    }
}

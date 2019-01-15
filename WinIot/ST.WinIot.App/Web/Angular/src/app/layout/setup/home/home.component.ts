import { Component, OnInit } from '@angular/core';
import { SetupService } from "../setup.service"
import { Home, Piece, PieceTypeEnum } from '@app/shared/classes'
@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.less']
})
export class homeComponent implements OnInit {
    constructor(private setupService: SetupService) {}

    ngOnInit() {
        this.setupService.ActivateBreadCrumb({
            active: true,
            icon: "fa-home",
            name: "Home",
            route: "/setup/home"
        });
    }
}

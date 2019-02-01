import { Injectable, EventEmitter, Output } from '@angular/core';
import { BreadCrumbItem } from '@app/shared/modules/bread-crumb/bread-crumb.component';
import { Home, Piece, PieceTypeEnum, Hub } from '@app/shared/classes'
@Injectable()
export class SetupService {
    @Output() fireBreadCrumbItemChanged: EventEmitter<Array<BreadCrumbItem>> = new EventEmitter();
    @Output() fireHeadlingChanged: EventEmitter<string> = new EventEmitter();
    constructor() {
        this.breadCrumbs = new Array<BreadCrumbItem>();
    }

    //For Page /setup/home
    public CurrentHome: Home;
    public Pieces: Array<Piece>;
    public homeSaved: boolean
    public piecesSaved: boolean;

    //for page /setup/hub
    public Hub: Hub;

    public Heading: string;

    public SetBreadCrumb(newValue: Array<BreadCrumbItem>) {
        this.breadCrumbs = newValue;
        this.fireBreadCrumbItemChanged.emit(newValue);
    }
    public setHeadling(headling: string) {
        this.Heading = headling;
        this.fireHeadlingChanged.emit(headling);
    }
    private breadCrumbs: Array<BreadCrumbItem>;
    public GetBreadCrumbs(): Array<BreadCrumbItem> { return this.breadCrumbs; }
    public ActivateBreadCrumb(item: BreadCrumbItem) {
        var allredyAdded = false;
        if (this.breadCrumbs)
            for (var i = 0; i < this.breadCrumbs.length; i++) {
                if (this.breadCrumbs[i].name == item.name) {
                    allredyAdded = true;
                    this.breadCrumbs[i].active = true;
                }
                else
                    this.breadCrumbs[i].active = false;
            }
        if (!allredyAdded)
            this.breadCrumbs.push(item);
        console.log('ActivateBreadCrumb', this.breadCrumbs);
        this.fireBreadCrumbItemChanged.emit(this.breadCrumbs);
    }
}

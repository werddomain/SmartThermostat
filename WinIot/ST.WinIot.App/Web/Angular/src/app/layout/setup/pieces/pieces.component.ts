import { Component, OnInit, Pipe, PipeTransform } from '@angular/core';
import { SetupService } from "../setup.service"
import { Home, Piece, PieceTypeEnum } from '@app/shared/classes'
import { FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
    selector: 'app-pieces',
    templateUrl: './pieces.component.html',
    styleUrls: ['./pieces.component.less']
})
export class piecesComponent implements OnInit {
    constructor(private setupService: SetupService) {
        this.currentPiece = {
            floor: 1,
            homeId: "",
            name: "",
            type: PieceTypeEnum.Living_Room
        };
    }
    currentPiece: Piece;
    pieces: Array<Piece>;
    piecesTypes: Array<SelectItem>;
    isInEdit: boolean = false;
    canSave: boolean = false;

    getPieceTypeName(type: PieceTypeEnum): string {
        return PieceTypeEnum[type].replace("_", " ");
    }
    ngOnInit() {
        this.setupService.setHeadling("Pieces");
        this.setupService.ActivateBreadCrumb({
            active: true,
            icon: "fa-vector-square",
            name: "Pieces",
            route: "/setup/pieces"
        });

        if (this.setupService.Pieces != null && this.pieces.length > 0)
            this.pieces = this.setupService.Pieces;
        this.pieces = new Array<Piece>();
        this.piecesTypes = this.getEnumValues();
    }
    cleanCurrentPeice() {
        this.currentPiece = this.clonePiece(this.currentPiece);
        this.currentPiece.name = "";
        this.currentPiece.pieceId = "";
    }
    addPeice() {
        this.currentPiece.homeId = this.setupService.CurrentHome.homeId;
        this.pieces.push(this.currentPiece);
        this.cleanCurrentPeice();
    }
    savePeice() {
        this.isInEdit = false;
      
        this.cleanCurrentPeice();
    }
    editPeice(index: number) {
        
        this.isInEdit = true;
        this.currentPiece = this.pieces[index];
    }
    removePeice(index: number) {
        this.pieces.splice(index, 1);
    }
    private clonePiece(item: Piece): Piece {
        return {
            floor: item.floor,
            name: item.name,
            type: item.type,
            homeId: item.homeId

        };
    }
    
    private getEnumValues(): Array<SelectItem> {
        /* Enums are listed like this in the object:
         * 0: "EnumName0"
         * 1: "EnumName1"
         * "EnumName0": 0
         * "EnumName1": 1
         * */
        let keys = new Array<SelectItem>();
        for (var enumMember in PieceTypeEnum) {
            //So we get only the integer one
            var isValueProperty = parseInt(enumMember, 10) >= 0
            if (isValueProperty) {
                //Then we get the corresponding name by PieceTypeEnum[enumMember]
                keys.push(<SelectItem>{ value: parseInt(enumMember), name: (<string>PieceTypeEnum[enumMember]).replace("_", " ") });

            }
        }
        return keys;
    }
    EndMessage: string;


}
export interface SelectItem {
    value: number;
    name: string;
}
@Pipe({
    name: 'enumToArray'
})
export class EnumToArrayPipe implements PipeTransform {
    transform(value, args: string[]): any {
        let keys = [];
        for (var enumMember in value) {
            var isValueProperty = parseInt(enumMember, 10) >= 0
            if (isValueProperty) {
                keys.push(<SelectItem>{ value: parseInt(enumMember), name: (<string>value[enumMember]).replace("_", " ") });
                // Uncomment if you want log
                // console.log("enum member: ", value[enumMember]);
            }
        }
        return keys;
    }
}

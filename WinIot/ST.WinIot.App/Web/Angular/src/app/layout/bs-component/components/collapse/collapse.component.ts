import { Component } from '@angular/core';

@Component({
    selector: 'app-collapse',
    templateUrl: './collapse.component.html',
    styleUrls: ['./collapse.component.less']
})
export class CollapseComponent {
    public isCollapsed = false;
}

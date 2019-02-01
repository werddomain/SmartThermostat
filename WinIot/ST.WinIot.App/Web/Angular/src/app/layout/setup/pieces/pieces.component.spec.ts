import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { piecesComponent } from './pieces.component';

describe('piecesComponent', () => {
	let component: piecesComponent;
	let fixture: ComponentFixture<piecesComponent>;

    beforeEach(
        async(() => {
            TestBed.configureTestingModule({
				declarations: [piecesComponent]
            }).compileComponents();
        })
    );

    beforeEach(() => {
		fixture = TestBed.createComponent(piecesComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});

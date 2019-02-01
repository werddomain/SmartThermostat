import { piecesModule } from './pieces.module';

describe('piecesModule', () => {
    let _piecesModule: piecesModule;

    beforeEach(() => {
        _piecesModule = new piecesModule();
    });

    it('should create an instance', () => {
        expect(piecesModule).toBeTruthy();
    });
});

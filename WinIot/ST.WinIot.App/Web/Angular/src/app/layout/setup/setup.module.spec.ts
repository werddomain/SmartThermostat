import { setupModule } from './setup.module';

describe('setupModule', () => {
    let _setupModule: setupModule;

    beforeEach(() => {
        _setupModule = new setupModule();
    });

    it('should create an instance', () => {
        expect(setupModule).toBeTruthy();
    });
});

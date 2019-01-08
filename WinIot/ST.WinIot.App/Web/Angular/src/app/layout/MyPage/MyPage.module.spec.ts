import { MyPageModule } from './MyPage.module';

describe('MyPageModule', () => {
    let myPageModule: MyPageModule;

    beforeEach(() => {
        myPageModule = new MyPageModule();
    });

    it('should create an instance', () => {
        expect(MyPageModule).toBeTruthy();
    });
});

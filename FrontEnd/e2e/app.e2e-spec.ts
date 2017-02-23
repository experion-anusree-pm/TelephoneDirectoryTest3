import { TelephoneDirectoryPage } from './app.po';

describe('telephone-directory App', function() {
  let page: TelephoneDirectoryPage;

  beforeEach(() => {
    page = new TelephoneDirectoryPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});

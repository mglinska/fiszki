import { shallowMount } from '@vue/test-utils';
import Navbar from '@/components/NavBar.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(Navbar)
});

describe('NavBar.vue', () => {
  it('jeśli uzytkownik jest zalogowany to wyświetla linki do stony głównej, kolekcji i wylogowania', async () => {
    await wrapper.setData({ user_id: 1 });
    const links = wrapper.findAll('.link');
    expect(links.length).toBe(3);
    expect(links[0].text()).toBe('Strona główna');
    expect(links[1].text()).toBe('Moje kolekcje');
    expect(links[2].text()).toBe('Wyloguj');
  });

  it('jeśli uzytkownik jest niezalogowany to wyświetla linki do stony głównej, logowania i rejestracji', async () => {
    await wrapper.setData({ user_id: null });
    const links = wrapper.findAll('.link');
    expect(links.length).toBe(3);
    expect(links[0].text()).toBe('Strona główna');
    expect(links[1].text()).toBe('Zaloguj');
    expect(links[2].text()).toBe('Zarejestruj');
  })
})
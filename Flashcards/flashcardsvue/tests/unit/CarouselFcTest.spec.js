import { shallowMount } from '@vue/test-utils';
import Carousel from '@/components/CarouselFc.vue';

let wrapper = null;

beforeEach(() => {
    wrapper = shallowMount(Carousel, {
        propsData: {
            coll_Name: 'Angielski',
            coll_Id: 1,
        }
    })
  });

test('Wyświetla karuzele z fiszkami po wybraniu opcji wyswietlania fiszek', async () => {
  const carousel = wrapper.find('#carousel')
    expect(carousel.exists()).toBe(false);

    await wrapper.setData({ start: true });

    const carousel2 = wrapper.find('#carousel')
    expect(carousel2.exists()).toBe(true);

    const text = wrapper.find('#coll-name')
    expect(text.text()).toContain('Angielski');
})

test('Wyświetla poprawną nazwę kolekcji przesłaną przez propa', async () => {
    await wrapper.setData({ start: true });

    const text = wrapper.find('#coll-name')
    expect(text.text()).toContain('Angielski');
})
import { shallowMount } from '@vue/test-utils';
import CollAddContent from '@/components/CollAddContent.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(CollAddContent)
});

describe('CollAddContent.vue', () => {
  it('renderuje formularz dodawania kolekcji', () => {
    expect(wrapper.find("#add_coll_form").exists()).toBe(true);
  });

  it('zawiera 2 pola tekstowe i 1 przycisk', () => {
    const button = wrapper.find("#btn");
    expect(wrapper.find('.text-field').exists()).toBe(true);
    expect(button.text()).toBe("Dodaj!");
  })
})

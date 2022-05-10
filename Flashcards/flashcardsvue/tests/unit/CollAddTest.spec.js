import { shallowMount } from '@vue/test-utils';
import CollAddContent from '@/components/CollAddContent.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(CollAddContent)
});

describe('CollAddContent.vue', () => {
  it('renderuje formularz dodawania kolekcji', () => {
    const form = wrapper.find("#add_coll_form");
    expect(form).toBeInstanceOf(Object)
  });

  it('zawiera 2 pola tekstowe i 1 przycisk', () => {
    const text_fields = wrapper.findAll(".text-field");
    const button = wrapper.find("#btn");
    expect(text_fields.length).toBe(2);
    expect(button.text()).toBe("Dodaj!");
  })
})

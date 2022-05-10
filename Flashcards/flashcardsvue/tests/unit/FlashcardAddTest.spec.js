import { shallowMount } from '@vue/test-utils';
import FlashcardAdd from '@/components/FlashcardAdd.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(FlashcardAdd)
});

describe('FlashcardAdd.vue', () => {
  it('renderuje formularz dodawania fiszki', () => {
    const form = wrapper.find("#add_fc_form");
    expect(form).toBeInstanceOf(Object)
  });

  it('zawiera 2 pola tekstowe i 1 przycisk', () => {
    const text_fields = wrapper.findAll(".text-field");
    const button = wrapper.find("#btn");
    expect(text_fields.length).toBe(2);
    expect(button.text()).toBe("Dodaj!");
  })
})
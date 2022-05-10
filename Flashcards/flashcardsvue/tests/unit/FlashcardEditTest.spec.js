import { shallowMount } from '@vue/test-utils';
import FlashcardEdit from '@/components/FlashcardEdit.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(FlashcardEdit)
});

describe('FlashcardEdit.vue', () => {
  it('renderuje formularz edycji fiszki', () => {
    const form = wrapper.find("#edit_fc_form");
    expect(form).toBeInstanceOf(Object)
  });

  it('zawiera 2 pole tekstowe i 1 przycisk', () => {
    const text_fields = wrapper.findAll(".text-field");
    const button = wrapper.find("#btn");
    expect(text_fields.length).toBe(2);
    expect(button.text()).toBe("Zapisz!");
  })
})
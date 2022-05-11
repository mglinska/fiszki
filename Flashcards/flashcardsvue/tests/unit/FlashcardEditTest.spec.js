import { shallowMount } from '@vue/test-utils';
import FlashcardEdit from '@/components/FlashcardEdit.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(FlashcardEdit)
});

describe('FlashcardEdit.vue', () => {
  it('renderuje formularz edycji fiszki', () => {
    expect(wrapper.find("#edit_fc_form").exists()).toBe(true);
  });

  it('zawiera 2 pole tekstowe i 1 przycisk', () => {
    const text_fields = wrapper.findAll(".text-field");
    const button = wrapper.find("#btn");
    expect(text_fields.length).toBe(2);
    expect(button.text()).toBe("Zapisz!");
  })
})
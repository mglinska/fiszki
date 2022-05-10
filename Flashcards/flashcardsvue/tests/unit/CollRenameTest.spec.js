import { shallowMount } from '@vue/test-utils';
import CollRename from '@/components/CollectionRename.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(CollRename)
});

describe('CollectionRename.vue', () => {
  it('renderuje formularz edycji kolekcji', () => {
    const form = wrapper.find("#rename_coll_form");
    expect(form).toBeInstanceOf(Object)
  });

  it('zawiera 1 pole tekstowe i 1 przycisk', () => {
    const text_fields = wrapper.findAll("#text-field");
    const button = wrapper.find("#btn");
    expect(text_fields.length).toBe(1);
    expect(button.text()).toBe("Zapisz!");
  })
})
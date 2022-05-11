import { shallowMount } from '@vue/test-utils';
import CollRename from '@/components/CollectionRename.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(CollRename)
});

describe('CollectionRename.vue', () => {
  it('renderuje formularz edycji kolekcji', () => {
    expect(wrapper.find("#rename_coll_form").exists()).toBe(true);
  });

  it('zawiera 1 pole tekstowe i 1 przycisk', () => {
    const button = wrapper.find("#btn");
    expect(wrapper.find(".text-field").exists()).toBe(true);
    expect(button.text()).toBe("Zapisz!");
  })
})
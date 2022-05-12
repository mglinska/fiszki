import { shallowMount } from '@vue/test-utils';
import ShareLink from '@/components/ShareLink.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(ShareLink, {
      propsData: {
          coll_name: 'nazwa kolekcji',
          coll_id: 1,
      }
  })
});

describe('ShareLink.vue', () => {
  it('generuje zaszyfrowany link do trybu uczenia', () => {
    let complete_link = wrapper.find("#link").text();
    let index = complete_link.lastIndexOf("-");
    const right_link = complete_link.substring(0, index);

    expect(right_link).toBe('http://localhost:8080/bmF6d2Ega29sZWtjamk=-MQ==');
  });

  it('wyswietla wygenerowany link w polu tekstowym', () => {
      expect(wrapper.find('#input_with_link').exists()).toBe(true);
  })
})
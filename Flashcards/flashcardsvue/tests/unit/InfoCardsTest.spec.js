import { shallowMount } from '@vue/test-utils';
import InfoCards from '@/components/InfoCards.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(InfoCards)
});

describe('InfoCards.vue', () => {
    it('Renderuje informacje 4 karty z informacjami tekstowymi na stronie głównej', async () => {
      await wrapper.setData({ users_sum: '5',
                              collections_sum: '10',
                              flashcards_sum: '15', 
                            });
      expect(wrapper.findAll(".infoCard").length).toBe(4);
    });

    it('Każda z 4 ma ustawione zdjęcie w tle', async () => {
        await wrapper.setData({ users_sum: '5',
                                collections_sum: '10',
                                flashcards_sum: '15', 
                            });
        expect(wrapper.findAll(".img").length).toBe(4);
      });
  })
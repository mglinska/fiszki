import { shallowMount } from '@vue/test-utils';
import CollectionsContant from '@/components/CollectionsContant.vue';

let wrapper = null;

beforeEach(() => {
  wrapper = shallowMount(CollectionsContant, {
        propsData: {
            user_name: 'User'
        }
    })
});

test('Sprawdza czy nazwa przekazywana w propie wyswietl sie poprawnie na stronie', () => {
    const user_name= wrapper.find('#user-name')
    expect(user_name.text()).toBe('User');
  })

// cos tu jest nie tak
test('Wyświertla tyle kolekcji ile użytkownik ma utowrzonych', async () => {
await wrapper.setData({ collections: [{Name: 'Angielski', Id_collection: 1}, 
                                    {Name: 'Niemiecki', Id_collection: 2},
                                    {Name: 'Historia', Id_collection: 3}
                        ] });
const collections = wrapper.findAll(".collection-item");
expect(collections.length).toBe(3);
})
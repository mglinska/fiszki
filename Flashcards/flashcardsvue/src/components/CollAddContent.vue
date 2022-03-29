<template>
    <h1 style="margin: 30px;">Dodaj kolekcje</h1>
    <form method="post">
    <label class="label3" for="i1">Podaj nazwę kolekcji</label><br>
    <input id="i1" class="input_temp" type="text" required name="collection_name"><br>
    <label class="label3">Chcesz dodać pierwszą fiszkę?</label><br>
    <label class="label3" for="i2">Pytanie</label><br>
    <input id="i2" class="input_temp" type="text" name="fc_question"><br>
    <label class="label3" for="i3">Odpowiedź</label><br>
    <input id="i3" class="input_temp" type="text" name="fc_answer"><br>
    <div></div>
    <input class="input_temp" type="submit" value="Gotowe">
    </form>
</template>

<style>

.label3 {
    background-color: rgb(214, 214, 214);

}

.input_temp {
    background-color: aquamarine;
}
</style>
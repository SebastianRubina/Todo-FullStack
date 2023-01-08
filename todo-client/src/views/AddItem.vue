<template>
  <div class="add-page">
    <AddForm @add-item="addItem" />
  </div>
</template>

<script>
import AddForm from "@/components/AddForm.vue";
import TodoItems from "@/views/TodoList.vue;"
import axios from "axios";

export default {
  name: "AddItem",
  components: {
    AddForm,
  },
  methods: {
    addItem(item) {
      // axios
      //   .post("https://todofullstack.azurewebsites.net/todoitem", item)
      //   .then((this.id = "00000000-0000-0000-0000-000000000000"))
      //   .catch((err) => console.log(err));
      TodoItems.push(item);
    },
  },
};
</script>

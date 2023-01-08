<template>
  <div class="todo-list" v-if="TodoItems">
    <TodoItem
      v-for="TodoItem in TodoItems"
      :key="TodoItem.Id"
      :item="TodoItem"
      @delete-item="deleteItem"
      @update-item="updateItem"
    />
  </div>
  <div v-else>
    <h1>Loading...</h1>
  </div>
</template>

<script>
// @ is an alias to /src
import TodoItem from "@/components/TodoItem.vue";
import axios from "axios";

export default {
  name: "TodoList",
  components: {
    TodoItem,
  },
  data() {
    return {
      TodoItems: null,
    };
  },
  created() {
    this.getItems();
  },
  methods: {
    getItems() {
      axios
        .get("https://todofullstack.azurewebsites.net/todoitem")
        .then((response) => {
          this.TodoItems = response.data;
        })
        .then(() => {
          this.TodoItems.sort(this.compareForSort);
        })
        .catch((err) => console.log(err));
    },
    deleteItem(id) {
      axios
        .delete(`https://todofullstack.azurewebsites.net/todoitem/${id}`)
        .then(() => this.getItems())
        .catch((err) => console.log(err));

      let date = new Date();
      let newItem = {
        title: "New Item " + (Math.floor(Math.random) * 100).toString() + "!",
        description: "To prevent from running out of items!",
        date: `${date.getFullYear()}/${date.getMonth() + 1}/${date.getDate()}`,
        time: `${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`,
      };
      axios
        .post("https://todofullstack.azurewebsites.net/todoitem", newItem)
        .then(
          (this.id = `00000000-${Math.floor(Math.random()) * 9}${
            Math.floor(Math.random()) * 9
          }${Math.floor(Math.random()) * 9}${
            Math.floor(Math.random()) * 9
          }-0000-0000-000000000000`)
        )
        .catch((err) => console.log(err));
    },
    updateItem(id) {
      axios
        .patch(`https://todofullstack.azurewebsites.net/todoitem/${id}`)
        .then(() => this.getItems())
        .catch((err) => console.log(err));
    },
    compareForSort(item1, item2) {
      return (
        (item1.completed && !item2.completed) ||
        item1.title.localeCompare(item2.title)
      );
    },
  },
};
</script>

<style scoped>
.todo-list {
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
  border-radius: 10px;
  width: 400px;
}
</style>

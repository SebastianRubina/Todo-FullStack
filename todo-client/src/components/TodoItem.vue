<template>
  <div
    class="todo-item"
    @mouseover="(showDescription = true), (showIcons = true)"
    @mouseleave="(showDescription = false), (showIcons = false)"
  >
    <div
      class="completed-stripe"
      :style="{ backgroundColor: item.completed ? '#42b983' : 'transparent' }"
    ></div>
    <div class="todo-info">
      <h3>{{ item.title }}</h3>
      <p class="date-time">{{ item.date }} at {{ item.time }}</p>
      <p v-show="showDescription">{{ item.description }}</p>
    </div>
    <div class="todo-icons" v-if="showIcons">
      <font-awesome-icon
        icon="fa-solid fa-x"
        class="x-icon todo-icon"
        @click="deleteItem(item.id)"
      />
      <font-awesome-icon
        v-if="!item.completed"
        icon="fa-solid fa-check"
        class="check-icon todo-icon"
        @click="updateItem(item.id)"
      />
      <font-awesome-icon
        v-else
        icon="fa-solid fa-rotate-left"
        class="check-icon todo-icon"
        @click="updateItem(item.id)"
      />
    </div>
  </div>
</template>

<script>
export default {
  name: "TodoItem",
  data() {
    return {
      showDescription: false,
      showIcons: false,
    };
  },
  props: {
    item: Object,
  },
  methods: {
    deleteItem(id) {
      this.$emit("delete-item", id);
    },
    updateItem(id) {
      this.$emit("update-item", id);
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.todo-item {
  display: flex;
  border-bottom: 1px solid rgba(0, 0, 0, 0.1);
}
.todo-info {
  text-align: left;
  margin-left: 25px;
  padding-block: 20px;
}
.date-time {
  color: grey;
  font-size: 0.8rem;
}
.todo-icons {
  margin-left: auto;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  margin-right: 15px;
}
.todo-icon:hover {
  transform: scale(1.1);
}
.completed-stripe {
  width: 7px;
}
.todo-item:first-child .completed-stripe {
  border-top-left-radius: 10px;
}
.todo-item:last-child .completed-stripe {
  border-bottom-left-radius: 10px;
}
.todo-item:first-child {
  border-top-left-radius: 10px;
  border-top-right-radius: 10px;
}
.todo-item:last-child {
  border-bottom: none;
  border-bottom-left-radius: 10px;
  border-bottom-right-radius: 10px;
}
.todo-item:hover {
  transform: scale(1.05);
  background-color: white;
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
  border-bottom: none;
}
.x-icon,
.check-icon {
  font-size: 1.2rem;
}
.x-icon {
  color: red;
}
.check-icon {
  color: green;
}
</style>

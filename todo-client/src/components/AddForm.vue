<template>
  <div class="add-form">
    <h2>Add Item</h2>
    <form @submit.prevent="onSubmit">
      <div class="form-field">
        <label for="title">Title</label>
        <input type="text" name="title" id="title" v-model.trim="title" />
      </div>
      <div class="form-field">
        <label for="description">Description</label>
        <input
          type="text"
          name="description"
          id="description"
          v-model.trim="description"
        />
      </div>
      <div class="form-field">
        <label for="date">Date</label>
        <input
          type="text"
          name="date"
          id="date"
          placeholder="December 12, 2023"
          v-model="date"
        />
      </div>
      <div class="form-field">
        <label for="time">Time</label>
        <input
          type="text"
          name="time"
          id="time"
          placeholder="15:30"
          v-model="time"
        />
      </div>
      <button class="submit-button" type="submit">Submit</button>
    </form>
  </div>

  <!-- TODO-ITEM PREVIEW -->
  <div class="preview" v-if="title || description || date || time">
    <h2 class="preview-title">Preview</h2>
    <div class="todo-item">
      <div class="completed-stripe"></div>
      <div class="todo-info">
        <h3>{{ title }}</h3>
        <p class="date-time">{{ date }} at {{ time }}</p>
        <p>{{ description }}</p>
      </div>
      <div class="todo-icons">
        <font-awesome-icon icon="fa-solid fa-x" class="x-icon todo-icon" />
        <font-awesome-icon
          icon="fa-solid fa-check"
          class="check-icon todo-icon"
        />
      </div>
    </div>
  </div>
  <!-- END OF TODO-ITEM PREVIEW -->
</template>

<script>
export default {
  name: "AddForm",
  data() {
    return {
      title: "",
      description: "",
      date: "",
      time: "",
    };
  },
  methods: {
    onSubmit() {
      if (
        this.title == "" ||
        this.description == "" ||
        this.date == "" ||
        this.time == ""
      ) {
        alert("Please fill in all the fields.");
        return;
      }
      let newItem = {
        title: this.title,
        description: this.description,
        date: this.date,
        time: this.time,
      };
      this.$emit("add-item", newItem);
      this.title = "";
      this.description = "";
      this.date = "";
      this.time = "";
    },
  },
};
</script>
<style scoped>
.add-form {
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
  border-radius: 10px;
  width: 400px;
  padding-block: 20px;
}
.preview-title {
  margin-block: 20px;
}
.form-field {
  display: flex;
  flex-direction: column;
  text-align: left;
  padding-inline: 15px;
  margin-bottom: 15px;
}
.form-field label {
  font-size: 1.2rem;
}
.form-field input[type="text"] {
  font-size: 1.1rem;
  padding: 5px 10px;
}
.submit-button {
  padding: 10px 50px;
  background-color: #42b983;
  border: none;
  color: white;
  font-size: 1.2rem;
  border-radius: 10px;
}
.submit-button:hover {
  cursor: pointer;
}
.submit-button:hover {
  transform: scale(1.1);
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
}
/* TODO-ITEM PREVIEW: Find a way to improve this, too much repetition */
.todo-item {
  display: flex;
  background-color: white;
  box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
  border-radius: 10px;
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
/* END OF TODO-ITEM PREVIEW */
</style>

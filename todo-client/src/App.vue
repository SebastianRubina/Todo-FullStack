<template>
  <h3>
    <strong
      >Note: functionality to push new items to the database has been disabled
      to stop people from posting inappropriate items for everyone to see.
      As POST requests have been disabled and new items can't be added,
      a new item will be added to the database everytime an existing item is
      deleted to prevent the site from running out of items to showcase.</strong
    >
  </h3>
  <nav>
    <router-link to="/">Todo</router-link> |
    <router-link to="/add">Add Item</router-link>
  </nav>
  <div class="container">
    <router-view />
  </div>
</template>

<script>
/* eslint-disable */
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}

.container {
  display: flex;
  justify-content: center;
}

p,
h1,
h2,
h3,
h4 {
  margin: 0;
  padding: 0;
}
</style>

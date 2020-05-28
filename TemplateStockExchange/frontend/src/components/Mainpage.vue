<template>
    <v-container>
        <v-container text-center>
            <v-row>
                <h1> Hello {{ this.user.name }}!</h1>
                <v-spacer></v-spacer>
                <h3>Balance: {{ this.user.balance }}$</h3>
            </v-row>
            
            
        </v-container>
        <v-container>
            <v-row no-gutters class="match">
                <v-col>
                    <v-card
                    class="pa-2 text-center"
                    outlined
                    tile
                    
                    >
                    <h2>Available Stocks</h2>


                    <v-container>                        
                        <v-container v-for="item in stocks" :key="item.id">
                            <v-row >
                                <h2>Stock: {{ item.name }}</h2>
                                <h2>{{ item.fullPrice}}$</h2>
                                <v-spacer></v-spacer>
                                <h2>Owner: {{ item.userId }}</h2>
                                <v-spacer></v-spacer>
                                <v-btn @click="buyStock(user.id, item)">Buy</v-btn>
                            </v-row>
                        </v-container>
                    </v-container>

                    </v-card>
                </v-col>
                <v-col order="1">
                    <v-card
                    class="pa-2 text-center"
                    outlined
                    tile
                    >
                    <h2>My Stocks</h2>

                    <v-container>                        
                        <v-container v-for="item in mystocks" :key="item.id">
                            <v-row >
                                <h2>Stock: {{ item.name }}</h2>
                                <h2>{{ item.fullPrice}}$</h2>
                                <v-spacer></v-spacer>
                                <h2>Owner: YOU</h2>
                                <v-spacer></v-spacer>
                                <v-btn @click="sellStock(user.id, item)">Sell</v-btn>
                            </v-row>
                        </v-container>
                    </v-container>

                    </v-card>
                </v-col>
            </v-row>

        </v-container>
    </v-container>
</template>

<script>
import axios from 'axios';
import { availablestockService, buyerService, myStocksService , sellerService, usersService } from '../variables'

export default {

    

  data() {
      return{
          user: {},
          stocks: {},
          mystocks: {}
      }
  },

  methods: {
      getStocks()
      {
        axios.get(availablestockService).then((response) => {
            this.stocks = response.data
            console.log(response.data)
        })
      },

      buyStock(id, stock)
      {

        axios.put(buyerService + id, stock)
        .then((response) => {
            console.log(response.data)
            if(response.data == 200)
            {
                console.log("im in!")
                this.updateUI()
            }
        }
        )
        .catch((error) =>
        console.log(error))
        .finally(
            this.getStocks()
        )

      },

      sellStock(id, stock)
      {
        if(this.user.balance < stock.fullPrice)
        {
            alert('Not Enough Money!')
            return
        }
        
        console.log(sellerService)
        axios.put(sellerService + id, stock)
        .then((response) => {
            console.log(response.data)
            if(response.data == 200)
            {
                console.log("im in!")
                this.updateUI()
            }
        }
        )
        .catch((error) =>
        console.log(error))
        .finally(
            this.getStocks()
        )

      },

      getMyStocks(id)
      {
          console.log("myid")
          console.log(id)
          console.log(myStocksService)
          axios.get(myStocksService + id).then((response) => {
            this.mystocks = response.data
            console.log(response.data)
        })
      },

      getUser(id){
        console.log("getUser Called")
        console.log(id)

        axios.get(usersService + id)
        .then((response) => {
            console.log("somelog")
            console.log(response.data)
            localStorage.setItem('userObject', JSON.stringify(response.data));
            this.user = JSON.parse(localStorage.getItem('userObject'));
        })
      },

      updateUI()
      {
          this.getMyStocks(this.user.id);
          this.getStocks(this.user.id);
          this.getUser(this.user.id);
      }

  },
  created() {
      this.user = JSON.parse(localStorage.getItem('userObject'));
      this.getStocks();
      this.getMyStocks(this.user.id);
      this.updateUI();
  }
};
</script>

<style scoped>

h2{
    padding-left: 2rem;
}

</style>
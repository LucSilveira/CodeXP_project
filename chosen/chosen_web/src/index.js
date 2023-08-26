import React from 'react'
import ReactDOM from 'react-dom'
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom'

// css comuns para todos
import './assets/css/reset.css'
import './assets/css/flexBox.css'
import '@fortawesome/fontawesome-free/css/all.min.css'
import 'bootstrap-css-only/css/bootstrap.min.css'
import 'mdbreact/dist/css/mdb.css'

// Páginas dos sistema chosen
import Login from './login'
import Home from './pages/montarPedidos/home'
import ListaPedidos from './pages/listaPedidos/listaPedidos'
import CadProdutos from './pages/cadastroProdutos/cadastroProdutos'
import CadCombos from './pages/cadastroCombos/cadastroCombos'
import Painel from './pages/painelControle/painelControle'

const RotasSistemas = (
    <Router>
        <>
            <Switch>
                <Route exact path='/' component={ Login }/>
                <Route path='/home' component={ Home }/>
                <Route path='/pedidos' component={ ListaPedidos }/>
                <Route path='/cadProdutos' component={ CadProdutos }/>
                <Route path='/cadCombos' component={ CadCombos }/>
                <Route path='/painel' component={ Painel }/>
            </Switch>
        </>
    </Router>
)

ReactDOM.render(RotasSistemas, document.getElementById('root'));
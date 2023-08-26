import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import Menu from '../../components/menu/menu'
import Rodape from '../../components/rodape/rodape'
import './cadastroProdutos.css'

class CadastroProdutos extends Component{
    render(){
        return(
            <>
                <Menu/>
                <Rodape/>
            </>
        )
    }
}

export default CadastroProdutos
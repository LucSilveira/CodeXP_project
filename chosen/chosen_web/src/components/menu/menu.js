import React from 'react'
import { Link } from 'react-router-dom'
import './menu.css'

function Menu(){
    return(
        <>
            <header className="cabecalho_mn">
                <section className="rowMenu_mn">
                    <img src={require('../../assets/img/logo-small.svg')} alt="logo da tabacaria chosen"/>
                    <div className="linksMenu_mn">
                        <Link to={''}>Produtos</Link>
                        <Link to={''}>Painel</Link>
                        <Link to={''}>Pedidos</Link>
                        <Link to={''}>Cad produtos</Link>
                        <Link to={''}>Cad combos</Link>
                    </div>
                </section>
            </header>
        </>
    )
}

export default Menu
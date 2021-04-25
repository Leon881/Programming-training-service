import React from "react";
import PropTypes from "prop-types";
import "./style.css";
import Page from "../../constants/Page";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

export default function NotFound({ onNavigateToPage }) {
    return (
        <div className='main-error'>
            <div className='error-name'>Ошибка 404</div>
            <div className='error-inf'>Запрашиваемая страница не существует или была удалена</div>
            <Link onClick= {()=>onNavigateToPage(Page.mainMenu)} className='error-return' to ='/'>Вернуться в главное меню </Link>
        </div>
    )
}

NotFound.propTypes = {
    onNavigateToPage: PropTypes.func.isRequired,
  };
  
import React from "react";
import PropTypes from "prop-types";
import "./style.css";
import Page from "../../constants/Page";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

export default function NavigationMenu({ onNavigateToPage }) {
  return (
    <div className="main-menu">
      <div className="main-menu__inner" onClick={(event) => onNavigateToPage(event.target.id)}>
        <Link id={Page.articles.text} className="block-menu lefter" to={Page.articles.route}>
          <span className="menu-text">Статьи</span>
        </Link>
        <Link id={Page.notes.text} className="block-menu left" to={Page.notes.route}>
          <span className="menu-text">Заметки</span>
        </Link>
        <Link id={Page.learningMenu.text} className="block-menu center" to={Page.learningMenu.route}>
          <div className="explainer">
            <span id={Page.learningMenu.text}> Наведи на меня</span>
          </div>
          <span className="menu-text">Обучение</span>
        </Link>
        <Link id={Page.testsMenu.text} className="block-menu right " to={Page.testsMenu.route}>
          <span className="menu-text">Тесты</span>
        </Link>
        <Link id={Page.flashCards.text} className="block-menu righter" to={Page.flashCards.route}>
          <span className="menu-text">Флешкарты</span>
        </Link>
      </div>
    </div>
  );
}

NavigationMenu.propTypes = {
  onNavigateToPage: PropTypes.func.isRequired,
};

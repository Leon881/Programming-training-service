import React from "react";
import PropTypes from "prop-types";
import "./style.css";
import Page from "../../constants/Page";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

export default function NavigationMenu({ onNavigateToPage }) {
  return (
    <div className="main-menu">
      <div className="main-menu__inner" onClick={(event) => onNavigateToPage(event.target.id)}>
        <Link id={Page.articles} className="block-menu lefter" to="/articles">
          <span className="menu-text">Статьи</span>
        </Link>
        <Link id={Page.notes} className="block-menu left" to="/notes">
          <span className="menu-text">Заметки</span>
        </Link>
        <Link id={Page.learningMenu} className="block-menu center" to="/learning">
          <div className="explainer">
            <span id={Page.learningMenu}> Наведи на меня</span>
          </div>
          <span className="menu-text">Обучение</span>
        </Link>
        <Link id={Page.tests} className="block-menu right " to="/tests">
          <span className="menu-text">Тесты</span>
        </Link>
        <Link id={Page.flashCards} className="block-menu righter" to="/flashcards">
          <span className="menu-text">Флешкарты</span>
        </Link>
      </div>
    </div>
  );
}

NavigationMenu.propTypes = {
  onNavigateToPage: PropTypes.func.isRequired,
};

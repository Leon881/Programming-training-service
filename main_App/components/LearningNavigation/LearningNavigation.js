import React from "react";
import PropTypes from "prop-types";
import "./style.css";
import Page from "../../constants/Page";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";

export default function LearningNavigation ({ onNavigateToPage}){
 return (
     <div className='learning-menu'>
        <ul className='learning-menu-list' onClick={(event) => onNavigateToPage(event.target.id)}>
            <li className='learning-menu-list__item'>
                <Link id={Page.learningSharp} className='learning-ref' to="/learning/sharp">Обучение C#</Link>
            </li>
            <li className='learning-menu-list__item'>
                <Link id={Page.learningJS} className='learning-ref' to="/learning/js">Обучение JS</Link>
            </li>
            <li className='learning-menu-list__item'>
                <Link id={Page.learningSQL} className='learning-ref' to="/learning/sql">Обучение SQL</Link>
            </li>
         </ul>
     </div>
 );
}

LearningNavigation.propTypes = {
    onNavigateToPage: PropTypes.func.isRequired,
  };
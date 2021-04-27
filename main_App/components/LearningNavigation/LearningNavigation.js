import React from "react";
import PropTypes from "prop-types";
import "./style.css";
import Page from "../../constants/Page";
import testAccordionMenu from "../../forTests/index"
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import { requestAccordionMenuInf } from "../../actionCreators";

export default function LearningNavigation ({ onNavigateToPage, setAccordionMenu, requestAccordionMenu}){
    const startLearning= async (event)=>{
        let route;
         switch (event.target.id){
        case Page.learningSharp: 
            route='sharp';
            break;
        case Page.learningJS:
            route='js';
            break;
        case Page.learningSQL:
             route='sql';
             break;
        default:
             break;
        }
        await requestAccordionMenu();
       // const menu=await (await fetch(`/api/lessons/${route}`)).json();
        const menu=testAccordionMenu; 
       await setAccordionMenu(menu);

    };
 return (
     <div  className='learning-menu'>
        <ul className='learning-menu-list' onClick={(event) => onNavigateToPage(event.target.id)}>
            <li className='learning-menu-list__item'>
                <Link id={Page.learningSharp} onClick={startLearning} className='learning-ref' to="/learning/sharp">Обучение C#</Link>
            </li>
            <li className='learning-menu-list__item'>
                <Link id={Page.learningJS}  onClick={startLearning} className='learning-ref' to="/learning/js">Обучение JS</Link>
            </li>
            <li className='learning-menu-list__item'>
                <Link id={Page.learningSQL} onClick={startLearning} className='learning-ref' to="/learning/sql">Обучение SQL</Link>
            </li>
         </ul>
     </div>
 );
}

LearningNavigation.propTypes = {
    onNavigateToPage: PropTypes.func.isRequired,
    setAccordionMenu: PropTypes.func.isRequired,
    requestAccordionMenu: PropTypes.func.isRequired,
  };
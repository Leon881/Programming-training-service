import React from "react";
import PropTypes from "prop-types";
import "./style.css";
import Page from "../../constants/Page";
import testAccordionMenu from "../../forTests/index"
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import LearningNavigationText from '../../constants/LearningNavigationText'
import TestingNavigationText from '../../constants/TestingNavigationText'
import { requestAccordionMenuInf } from "../../actionCreators";

export default function LanguageNavigation ({ onNavigateToPage, setAccordionMenu, requestAccordionMenu, page}){
    const start= async (event)=>{
        let route;
         switch (event.target.id){
        case Page.learningSharp.text: 
            route='sharp';
            break;
        case Page.learningJS.text:
            route='js';
            break;
        case Page.learningSQL.text:
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
    const text= (page===Page.learningMenu.text) ? LearningNavigationText : TestingNavigationText;
    let menuForm=[];
    for (let el of text){
        menuForm.push(<li key={el.key} className='learning-menu-list__item'>
        <Link id={el.page.text} onClick={start} className='learning-ref' to={el.page.route}>{el.text}</Link>
    </li>)
    }
 return (
     <div  className='learning-menu'>
        <ul className='learning-menu-list' onClick={(event) => onNavigateToPage(event.target.id)}>
           {menuForm}
         </ul>
     </div>
 );
}

LanguageNavigation.propTypes = {
    onNavigateToPage: PropTypes.func.isRequired,
    setAccordionMenu: PropTypes.func.isRequired,
    requestAccordionMenu: PropTypes.func.isRequired,
    page: PropTypes.string.isRequired
  };
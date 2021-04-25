import React, { useState, useRef, useEffect } from "react";
import ReactDOM from "react-dom";
import PropTypes from "prop-types";
import { createStore, applyMiddleware } from "redux";
import { rootReducer } from "../reducers";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import logger from "redux-logger";
import { Provider } from "react-redux";
import NavigationMenu from "../containers/NavigationMenu";
import Articles from "../containers/Articles";
import Notes from "../containers/Notes";
import Tests from "../containers/Tests";
import LearningNavigation from "../containers/LearningNavigation";
import LearningSharp from "../containers/LearningSharp";
import LearningJS from "../containers/LearningJS";
import LearningSQL from "../containers/LearningSQL";
import FlashCardsDecks from "../containers/FlashCardsDecks";
import NotFound from "../containers/NotFound";
import "./style.css";
import { setInformation } from "../actionCreators/index";

const store = createStore(rootReducer, applyMiddleware(logger));

class App extends React.Component {
  constructor(props) {
    super(props);
  }

  async componentDidMount() {
  
  }
  
  render() {
    return (
      <Provider store={store}>
        <div className="page">
          <header id="header" className="header">
            <div className="header__logo">Programming-training service</div>
            <div className="profile flex-block">
              <div className="link auth">
                  <a href="/account/login">Вход</a>
              </div>
              <div className="link regist">
                 <a href="/account/register">Регистрация</a>
             </div>
             </div>
          </header>
          <main className="content">
            <Switch>
              <Route exact path="/" component={NavigationMenuPage} />
              <Route exact path="/articles" component={ArticlesPage} />
              <Route exact path="/flashcards" component={FlashCardsPage} />
              <Route exact path="/notes" component={NotesPage} />
              <Route exact path="/tests" component={TestsPage} />
              <Route exact path="/learning" component={LearningPage} />
              <Route exact path="/learning/sharp" component={LearningSharpPage} />
              <Route exact path="/learning/js" component={LearningJSPage} />
              <Route exact path="/learning/sql" component={LearningSQLPage} />
              <Route component={NotFoundPage} />
            </Switch>
          </main>
          <footer id="footer" className="footer">
            <div className="copyright-info">
                <a href="#header" className="copyright-info__logo"> 
                  <img src="src/img/vamLogo.jpg" alt="CompanyLogo" />
                </a>
            </div>
          </footer>
        </div>
      </Provider>
    );
  }
}

App.propTypes = {};

class NavigationMenuPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <NavigationMenu />
      </Provider>
    );
  }
}

class ArticlesPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <Articles />
      </Provider>
    );
  }
}

class FlashCardsPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <FlashCardsDecks />
      </Provider>
    );
  }
}

class NotesPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <Notes />
      </Provider>
    );
  }
}

class TestsPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <Tests />
      </Provider>
    );
  }
}
class LearningPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <LearningNavigation />
      </Provider>
    );
  }
}

class LearningSharpPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <LearningSharp/>
      </Provider>
    );
  }
}

class LearningJSPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <LearningJS/>
      </Provider>
    );
  }
}

class LearningSQLPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
        <LearningSQL/>
      </Provider>
    );
  }
}

class NotFoundPage extends React.Component {
  render() {
    return (
      <Provider store={store}>
      <NotFound />
    </Provider>
    );
  }
}

ReactDOM.render(
  <Router>
    <App />
  </Router>,
  document.getElementById("app")
);
